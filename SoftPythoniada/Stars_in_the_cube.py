def check_star():
    base = cube[x][y][z]
    if cube[x-1][y][z] == base and\
        cube[x+1][y][z] == base and\
        cube[x][y-1][z] == base and\
        cube[x][y+1][z] == base and\
        cube[x][y][z-1] == base and\
        cube[x][y][z+1] == base:
        return True
    return False
result = {}
count = 0
n = int(input())
cube = [["".join(j.strip().split(" ")) for j in input().split("|")] for i in range(n)]
# print(cube)
for x in range(1,n-1):
    for y in range(1,n-1):
        for char in set(cube[x][y]):
            index = cube[x][y].find(3*char)
            while index>-1:
                z=index+1
                if check_star():
                    result[cube[x][y][z]] = result.get(cube[x][y][z],0) + 1
                    count +=1
                index = cube[x][y].find(3*char,index+1)
print(count)
for letter in sorted(result):
    print("{} -> {}".format(letter,result[letter]))