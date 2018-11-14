package me.tatwd.demo;

/**
 * key-value node
 * to build a node chain
 *
 * @author _king (@tatwd)
 */
public class Node {

    public Node prev;
    public Node next;
    public String key;
    public String value;

    public Node(String key, String value) {
        this.key = key;
        this.value = value;
    }
}
