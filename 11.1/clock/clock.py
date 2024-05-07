class Counter:
    def __init__(self, name):
        self._name = name
        self._count = 0

    def Increment(self):
        self._count += 1

    def Reset(self):
        self._count = 0

    def get_name(self):
        return self._name
    def set_name(self, value):
        self._name = value

    def get_count(self):
        return self._count

    name = property(fget=get_name, fset=set_name)
    count = property(fget=get_count)

class Clock:

    def __init__(self):
        self._hour = 0
        self._minute = 0
        self._second = 0
        self._counter = Counter("counter1")

    def ticks(self):
        self._counter.Increment()

    def reset_time(self):
        self._counter.Reset()

    def shows(self):
        self._hour = (self._counter.count // 3600) % 24
        self._minute = (self._counter.count % 3600) // 60
        self._second = (self._counter.count % 3600) % 60
        return f"{self._hour:02d}:{self._minute:02d}:{self._second:02d}"

clock1 = Clock()
for i in range(10000):
    clock1.ticks()

print(clock1.shows())