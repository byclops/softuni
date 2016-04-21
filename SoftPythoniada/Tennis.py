from collections import defaultdict
from collections import OrderedDict
# from pprint import pprint

def last_element(od):
    return od[list(ordered_pairs.keys())[-1]]

def fine_sort(od, candidates):
    partners = set()
    for candidate in candidates:
        partners = partners.union(od[candidate])
    best_partner = sorted(partners, key = lambda item: len(item))[-1]
    for candidate in candidates:
        if best_partner in od[candidate]:
            od.move_to_end(candidate)
            return

pairs = defaultdict(set)

data_reached = False

line = input()
while line !='END':
   stripped_line = line.strip()
   if data_reached:
       pair = stripped_line.split(' - ')
       pairs[pair[0]].add(pair[1])
       pairs[pair[1]].add(pair[0])
   elif stripped_line == 'Connections:':
       data_reached = True
   line = input()

# with open("tennis-data.txt") as f:
#     for line in f:
#         stripped_line = line.strip()
#         if stripped_line =='END':
#             break
#         if data_reached:
#             pair = stripped_line.split(' - ')
#             pairs[pair[0]].add(pair[1])
#             pairs[pair[1]].add(pair[0])
#         elif stripped_line == 'Connections:':
#             data_reached = True

ordered_pairs = OrderedDict(sorted(pairs.items(), key = lambda item: len(item[1]),reverse = True))

count = 0
while len(ordered_pairs) >0:
    count += 1
    min_count = len(last_element(ordered_pairs))
    candidates_queue = [value for value in ordered_pairs if len(ordered_pairs[value]) == min_count]
    # print("Candidates:")
    # print(candidates_queue)
    fine_sort(ordered_pairs, candidates_queue)
    # print("Best candidate:")
    # print(list(ordered_pairs.keys())[-1])
    player_one = ordered_pairs.popitem()
    player_one_friends = sorted([friend for friend in player_one[1]], key = lambda item: len(ordered_pairs[item]))
    for friend in player_one[1]:
        # remove player_one form his friends sets
        ordered_pairs[friend].remove(player_one[0])

    ordered_pairs.move_to_end(player_one_friends[0])
    player_two = ordered_pairs.popitem()

    for friend in player_two[1]:
        # remove player_two form his friends sets
        ordered_pairs[friend].remove(player_two[0])

    ordered_pairs = OrderedDict(sorted(ordered_pairs.items(), key = lambda item: len(item[1]),reverse = True))

    while len(ordered_pairs)>0:
        #clear orphan players
        tmp = ordered_pairs.popitem()
        if len(tmp[1]) != 0:
            ordered_pairs[tmp[0]] = tmp[1]
            break

print (count)


