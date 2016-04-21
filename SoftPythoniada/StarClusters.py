class point:
    def __init__(self,x,y):
        self.x = x
        self.y = y

class galaxy:
    def __init__(self, x, y):
        self.stars = [point(x,y)]
        self.x = x
        self.y = y

    def calc_center(self):
        self.x = 0
        self.y = 0
        for star in self.stars:
            self.x += star.x
            self.y += star.y
        self.x = round(self.x/len(self.stars))
        self.y = round(self.y/len(self.stars))

    def add(self,star):
        self.stars.append(star)
        self.calc_center()

    def remove(self,star):
        self.stars.remove(star)
        self.calc_center()

    def dist_to_center(self, star):
        return (star.x - self.x) * (star.x - self.x) + (star.y - self.y) * (star.y - self.y)

n = int(input())
galaxies = {}

# input galaxies
for i in range(n):
    line = input().split(" (")
    coords = [int(j) for j in line[1][:-1].split(", ")]
    galaxies[line[0]] = galaxy(*coords)
stars = []
line = input()

#input stars
while line != "end":
    new_stars = [i.split(", ") for i in line.strip()[1:-1].split(") (")]
    stars.extend([point(int(star[0]),int(star[1])) for star in new_stars])
    line = input()

# initial star distribution
for current_star in stars:
    distances={name: galaxy.dist_to_center(current_star) for name, galaxy in galaxies.items()}
    home_galaxy = min(distances, key=distances.get)
    galaxies[home_galaxy].add(current_star)

# check for correctness and reshuffle
while True:
    correct_distribution  = True
    for home_galaxy in galaxies.keys():
        if not correct_distribution:
            break
        for star in galaxies[home_galaxy].stars[1:]:
            if not correct_distribution:
                break
            dist_to_home = galaxies[home_galaxy].dist_to_center(star)
            for galaxy in galaxies:
                if galaxies[galaxy].dist_to_center(star)<dist_to_home:
                    galaxies[home_galaxy].remove(star)
                    galaxies[galaxy].add(star)
                    correct_distribution = False
                    break
    if correct_distribution:
        break
        
#output
for name,galaxy in sorted(galaxies.items()):
    print("{} ({}, {}) -> {} stars".format(name, galaxy.x,galaxy.y, len(galaxy.stars)))
