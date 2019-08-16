# supported functions:

1) empty ctor:

```c#
MyHashMap<key - type, value - type> hashMap = new MyHashMap<key - type, value - type>();
```

2) put function, to set key - value pairs in the map, tends to O(1) complexity wise (although theoretically, in a very low probability
can tend to O(n) - if all elements get same hash):

```c#
hashMap.put(some-key, some-value);
```
* you CAN NOT use the same key twice - you'll recive a error message

![im1](https://user-images.githubusercontent.com/44900773/63168357-94e33600-c03c-11e9-81fa-3e05c02a64b8.png)

3) get function, to recive a value out of a key, tends to O(1) complexity wise 

```c#
VALUETYPE output = outhashMap.get(some-key);
```
4) you can also use '[]' operator to recive a value out of a key:

```c#
VALUETYPE output = outhashMap.[some-key];
```

* in both cases if the key is not found the next message will be recived, and the value returned will be the default value of the value type

![im2](https://user-images.githubusercontent.com/44900773/63168626-5ac66400-c03d-11e9-94d9-71677d60a935.png)

5) 'foreach' is also supported:

```c#
 foreach (var element in hashMap)
            {
                Console.WriteLine(element);
            }
```

console output:



![im3](https://user-images.githubusercontent.com/44900773/63168845-ed670300-c03d-11e9-86a7-35ac304b17f8.png)

# basic use example:


![im3](https://user-images.githubusercontent.com/44900773/63168972-4898f580-c03e-11e9-869d-023504da056c.png)


