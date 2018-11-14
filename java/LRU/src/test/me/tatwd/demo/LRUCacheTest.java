package me.tatwd.demo;

import org.junit.Test;

import org.junit.Assert;

public class LRUCacheTest {

    private LRUCache lruCache;

    public LRUCacheTest() {
        lruCache = new LRUCache(5);
        lruCache.put("001", "用户 1 信息");
    }

    @Test
    public void get() {
        Assert.assertEquals("should has a node of which key is `001`", "用户 1 信息", lruCache.get("001"));
    }

    @Test
    public void put() {
        lruCache.put("002", "用户 2 信息");
        Assert.assertNotNull("should not be null", lruCache.get("002"));
    }

    @Test
    public void remove() {
        lruCache.remove("001");
        Assert.assertNull("should be null", lruCache.get("001"));
    }
}