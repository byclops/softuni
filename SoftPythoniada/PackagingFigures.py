import math
import heapq

class Point:
    def __init__(self,x,y):
        self.x = x
        self.y = y

class Rectangle:

    def __init__(self,name,ax,ay,bx,by):
        self.name = name
        self.ax = int(ax)
        self.ay = int(ay)
        self.bx = int(bx)
        self.by = int(by)
        self.bp=[]

        self.bp.append(Point(self.ax, self.ay))
        self.bp.append(Point(self.bx, self.ay))
        self.bp.append(Point(self.bx, self.by))
        self.bp.append(Point(self.ax, self.by))

    def contains(self, figure):
        for point in figure.bp:
            if not (self.ax<=point.x<=self.bx and\
                self.by<=point.y<=self.ay):
                return False
        return True

class Circle():

    def __init__(self,name,ox,oy,r):

        self.name = name
        self.ox = int(ox)
        self.oy = int(oy)
        self.r = int(r)
        self.r_squared = self.r*self.r
        self.bp =[]

        self.bp.append(Point(self.ox, self.oy-self.r))
        self.bp.append(Point(self.ox+self.r, self.oy))
        self.bp.append(Point(self.ox, self.oy+self.r))
        self.bp.append(Point(self.ox-self.r, self.oy))
    def contains(self, figure):
        for point in figure.bp:
            delta_x  = (point.x-self.ox)
            delta_y = (point.y-self.oy)
            if delta_x*delta_x+delta_y*delta_y>self.r_squared:
                return False
        return True

class Square(Rectangle):
    def __init__(self,name,ax, ay, s):
        ax = int(ax)
        ay = int(ay)
        s = int(s)
        super().__init__(name,ax,ay,ax+s,ay-s)

class Node:
    def __init__(self, figure, next = None):
        self.figure = figure
        self.next = next

class Branch:
    def __init__(self, root_node):
        self.root = root_node
        self.last = root_node
        self.size = 1
        # self.nodes = set(root_node)
    def append(self,node):
        self.last.next = node
        self.last = node
        self.size +=1
    def prepend(self,node):
        node.next = self.root
        self.root = node
        self.size +=1
    def insert(self,node):
        next_node=self.root.next
        current_node = self.root
        while next_node and next_node.figure.contains(node.figure):
            current_node = next_node
            next_node = next_node.next
        if next_node and not node.figure.contains(next_node.figure):
            # split the branch
            result = self.subbranch(next_node)
            result.append(Node(node.figure))
            return result
        current_node.next = node
        node.next = next_node
        self.size +=1
        return None

    def subbranch(self,end_node):
        result = Branch(Node(self.root.figure))
        index = self.root.next
        while index and index.figure!=end_node.figure:
            result.append(Node(index.figure))
            index = index.next
        return result








    # def find_place(self,node):
    #     next_node=self.root.next
    #     parent_node = self.root
    #     while next_node and next_node.figure.contains(node.figure):
    #         parent_node = next_node
    #         next_node = next_node.next
    #     return parent_node

    # def add(self,node):
    #     # in case the new node contains the root of the branch
    #     if node.figure.contains(self.root.figure):
    #         # self.nodes.append(node)
    #         node.next = self.root
    #         self.root = node
    #         self.size +=1
    #         #return True
    #         return None
    #     # in case the
    #     elif self.root.figure.contains(node.figure):
    #         next_node=self.root.next
    #         current_node = self.root
    #         while next_node and next_node.figure.contains(node.figure):
    #             current_node = next_node
    #             next_node = next_node.next
    #             #if next_node == None:
    #             #    break
    #         if next_node and not node.figure.contains(next_node.figure):
    #             # split the branch
    #             result = Branch(Node(self.root.figure))
    #             index = self.root.next
    #             while index and index!=next_node:
    #                 result.append(Node(index.figure))
    #                 index = index.next
    #             result.append(Node(node.figure))
    #             return result
    #
    #         else:
    #             if not next_node:
    #                 self.last = node
    #             node.next = next_node
    #             current_node.next = node
    #             self.size +=1
    #             return None
    #             #return True
    #     else:
    #         return None
    def __str__(self):
        node = self.root
        result = []
        while node:
            result.append(node.figure.name)
            node = node.next
        return " < ".join(result)

create_figure = {"rectangle": Rectangle, "square":Square, "circle":Circle}

test_points = [Point(-30,40), Point(55,-10)]

line = input()
figures =[]
while line !="End":
    params = line.split(" ")
    figures.append( create_figure[params[0]](*params[1:]))
    line = input()

branches = []

for figure in figures:
    #current_node = Node(figure)
    new_branches = []
    for branch in branches:
        if branch.root.figure.contains(figure):
            result = branch.insert(Node(figure))
            if result:
                new_branches.append(result)
        elif figure.contains(branch.root.figure):
            branch.prepend(Node(figure))
    if new_branches:
        branches.extend(new_branches)
    branches.append(Branch(Node(figure)))


max_branch_size = 0
long_branches =[]
for branch in branches:
    if branch.size > max_branch_size:
        max_branch_size = branch.size
        long_branches = [branch.__str__()]
    elif branch.size == max_branch_size:
        long_branches.append(branch.__str__())

# long_branches.sort()
# print([branch.__str__() for branch in branches])
print(sorted(long_branches)[0])


# print([branch.__str__() for branch in branches])



