package me.tatwd.demo;

import java.util.HashMap;

/**
 * 基于 LRU 算法的缓存类
 *
 * @author _king (@tatwd)
 */
public class LRUCache {

    /**
     * 缓存上限
     */
    private int limit;

    /**
     * 头节点 - 最少访问节点
     */
    private Node head;

    /**
     * 尾节点 - 最近访问节点
     */
    private Node end;

    /**
     * Hash Node Chain
     */
    private HashMap<String, Node> hashMap;

    public  LRUCache(int limit) {
        this.limit = limit;
        hashMap = new HashMap<>();
    }

    /**
     * 尾部插入节点
     * @param node  待插入的节点
     */
    private void addNode(Node node) {
        if (end != null) {
            end.next = node;
            node.prev = end;
            node.next = null;
        }
        end = node;
        if (head == null) {
            head = node;
        }
    }

    /**
     * 删除节点
     * @param node 被删除的节点
     * @return 被删节点的 key
     */
    private String removeNode(Node node) {
        if(node == end) {
            end = end.prev;
        } else if(node == head) {
            head = head.next;
        } else {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        return node.key;
    }

    /**
     * 刷新被访问的节点位置
     * @param node 被访问的节点
     */
    private  void refreshNode(Node node) {
        // node 是尾节点则无需移动
        if (node == end) {
            return;
        }

        // 移除节点
        removeNode(node);

        // 重新插入节点
        addNode(node);
    }

    public String get(String key) {
        Node node = hashMap.get(key);
        if (node == null) {
            return null;
        }
        refreshNode(node);
        return node.value;
    }

    public void put(String key, String value) {
        Node node = hashMap.get(key);
        if (node == null) {
            // 如果 key 不存在则插入 node
            if (hashMap.size() >= limit) {
                String oldKey = removeNode(head);
                hashMap.remove(oldKey);
            }
            node = new Node(key, value);
            addNode(node);
            hashMap.put(key, node);
        } else {
            // 如果 key 存在则刷新 node
            node.value = value;
            refreshNode(node);
        }
    }

    public void remove(String key) {
        Node node = hashMap.get(key);
        removeNode(node);
        hashMap.remove(key);
    }
}
