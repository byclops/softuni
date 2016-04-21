numbers =[int(input()) for i in range(4)]
half_sum, odd = divmod(sum(numbers),2)

if not odd:
    for num in numbers:
        if num == half_sum:
            print("Yes\n{}".format(half_sum))
            exit()
    for num in numbers[1:]:
        if numbers[0] + num == half_sum:
            print("Yes\n{}".format(half_sum))
            exit()
print("No")