from datetime import timedelta, datetime
import collections


def read():
    return input()

def floyd_warshall(g):
    vertices = g.keys()
    d = g
    for v2 in vertices:
        d = {v1: {v3: min(d[v1][v3], d[v1][v2] + d[v2][v3])
                 for v3 in vertices}
             for v1 in vertices}
    return d

class CameraEntry:
    def __init__(self, city_name, tstamp):
        self.city = city_name
        self.timestamp = tstamp

read()
line = read()
roads =[]
cities = set()

while line !="Records:":
    #elements = line.split(" ")
    roads.append(line.split(" "))
    cities.add(roads[-1][0])
    cities.add(roads[-1][1])
    line = read()
keys = sorted(list(cities))

adj_matrix = {i:{j:float("inf") for j in range(len(keys))} for i in range(len(keys))}
for i in range(len(cities)):
    adj_matrix[i][i] =0

for entry in roads:
    i1 = keys.index(entry[0])
    i2 = keys.index(entry[1])
    value = float(entry[2])/float(entry[3])
    adj_matrix[i1][i2] = value
    adj_matrix[i2][i1] = value

shortest_paths = floyd_warshall(adj_matrix)

cars = collections.defaultdict(list)
line = read()
while line !="End":
    elements = line.split(" ")
    t = datetime.strptime(elements[2],"%H:%M:%S")
    cars[elements[1]].append(CameraEntry(elements[0],t))
    line = read()

#speeders = set()
for car in sorted(cars.keys()):
    last_entry = None
    for entry in sorted(cars[car], key = lambda x: x.timestamp):
        if last_entry:
            td = entry.timestamp - last_entry.timestamp
            index1 = keys.index(last_entry.city)
            index2 = keys.index(entry.city)
            if float("inf")>shortest_paths[index1][index2]>td.seconds/3600:
                #speeders.add(car)
                print(car)
                break
        last_entry = entry