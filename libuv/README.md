libuv: v1.x

```
while there are still events to process:
    e = get the next event
    if there is a callback associated with e:
        call the callback
```

> All handles and requests have a `void*` data member which you can set to the context and cast back in the callback.  [uvbook](http://nikhilm.github.io/uvbook/basics.html#storing-context)
