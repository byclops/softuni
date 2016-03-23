from collections import defaultdict
##from pprint import pprint

def subtract_seq(seq1, seq2):
##    print(seq1)
##    print(seq2)
    result = seq1[:]
    for num in seq2:
        result.remove(num)
    return result

def can_split_in_half(seq,s):
##    print("--1/2: seq={}".format(seq))
    possible_sums = defaultdict(list)
    possible_sums[0].append(0)
    for num in seq:
        for i in list(possible_sums.keys()):
            current_sum = i + num
            if current_sum < s:
##                print("--1/2: num={}, i={}, sum={}".format(num,i,current_sum))
                if i in seq:
                    possible_sums[current_sum].append(i)
                else:
                    possible_sums[current_sum].extend(possible_sums[i])
                possible_sums[current_sum].append(num)
            elif current_sum == s:
##                print("----1/2: num={}, i={}, sum={}".format(num,i,current_sum))
                return True

def can_split_in_three(seq,s):
    possible_sums = {}
    possible_sums[0] = 0
    for num in seq:
        for i in list(possible_sums.keys()):
            current_sum = i + num
            if current_sum < s and current_sum not in possible_sums:
                possible_sums[current_sum] = num
            if current_sum == s:
                possible_sums[current_sum] = num
                participants = recover_path(possible_sums,s)
                non_participants = subtract_seq(seq, participants)
##                print("1/3: num={}, i={}, path={}".format(num,i,recover_path(possible_sums,s)))
                if can_split_in_half(non_participants,s):
                    return True
                
def recover_path(sums, target):
    path = []
    while target > 0:
        last_num = sums[target]
        path.append(last_num)
        target -=last_num
    return path
    
n = int(input())
for i in range(n):
    presents = [int(s) for s in input().split(" ")]
    s,r = divmod(sum(presents),3)
    if r == 0 and can_split_in_three(presents,s):
        print("Yes")
    else:
        print("No")
    
