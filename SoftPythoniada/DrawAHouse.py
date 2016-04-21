n = int(input())
width = 2*n -1
print((n-1)*"."+"*"+(n-1)*".")
print((n-2)*"."+"*"+" "+"*"+(n-2)*".")
for i in range(2,n-1):
    dots = (n-1-i)*"."
    print(dots+"*"+(2*i-1)*" "+"*"+dots)
if n>2:
    print(" ".join(["*"for j in range(n)]))
base = "+"+(width-2)*"-"+"+"
print(base)
for i in range(n-2):
    print("|"+(width-2)*" "+"|")
print(base)