import datetime
import dateutil

def parse_input(line):
    elements = line.split("::")
    days =0
    if len(elements)>1:
        days = int(elements[0])
    time = elements[-1].split(":")
    result = datetime.timedelta(
        days=days,
        hours=int(time[0]),
        minutes = int(time[1]))
    return result

period1 = parse_input(input())
period2 = parse_input(input())
total = period1+period2
seconds = total.seconds
hours,minutes = divmod(total.seconds,3600)
minutes = minutes/60

if total>=datetime.timedelta(days=1):
    print("{}::{:.0f}:{:02d}".format(total.days, hours, round(minutes)))
else:
    print("{:.0f}:{:02d}".format(hours, round(minutes)))
