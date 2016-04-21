import math

def calc_dist(x1,y1,x2,y2):
    return math.hypot(x2-x1,y2-y1)

class circle:
    def __init__(self,x,y,r):
        self.x = x
        self.y = y
        self.r = r
    def contains_point(self,x,y):
        if math.hypot(self.x-x,self.y-y)<=self.r:
            return True
        else:
            return False
class rectangle:
    def __init__(self,x1,y1,x3,y3):
        self.x1 = x1
        self.y1 = y1
        self.x2 = x3
        self.y2 = y1
        self.x3 = x3
        self.y3 = y3
        self.x4 = x1
        self.y4 = y3

        self.x5 = (x1+x3)/2
        self.y5 = y1
        self.x6 = x3
        self.y6 = (y1+y3)/2
        self.x7 = (x1+x3)/2
        self.y7 = y3
        self.x8 = x1
        self.y8 = (y1+y3)/2

def calc_intersect(f):
    c = circle(*f["circle"])
    r = rectangle(*f["rectangle"])
    p1 = c.contains_point(r.x1,r.y1)
    p2 = c.contains_point(r.x2,r.y2)
    p3 = c.contains_point(r.x3,r.y3)
    p4 = c.contains_point(r.x4,r.y4)
    p5 = c.contains_point(r.x5,r.y5)
    p6 = c.contains_point(r.x6,r.y6)
    p7 = c.contains_point(r.x7,r.y7)
    p8 = c.contains_point(r.x8,r.y8)
    if p1 and p2 and p3 and p4:
        return "Rectangle inside circle"
    elif not (p1 and p2 and p3 and p4):
        if not(c.contains_point(r.x5,r.y5) and\
            c.contains_point(r.x6,r.y6) and\
            c.contains_point(r.x7,r.y7) and\
            c.contains_point(r.x8,r.y8)):
            return "Circle inside rectangle"
        else:
            return"Rectangle and circle cross"
    else:
        return"Rectangle and circle cross"
        # return "Circle inside rectangle"
n = int(input())
for i in range(n):
    f = {}
    for j in range(2):
        line = input().split("(")
        f[line[0]] =[float(parameter)for parameter in line[1][:-1].split(", ")]
    print(calc_intersect(f))