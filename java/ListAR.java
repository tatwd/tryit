import java.util.*;

// List Add & Remove
public class ListAR {
	public static void main(String[] args) {
		List<String> items = new ArrayList<String>() {{
			add("1");
			add("2");
			add("3");
		}};

		// 无法删除连续的重复元素
		// for (int i = 0; i < items.size(); i++) {
		// 	if (items.get(i).equals("1")) {
		// 		items.remove(i);
		// 	}
		// }

		// 会集合错误检测机制：fail-fast
		// modCount != expectedModCount
		// 触发 java.util.ConcurrentModificationException
		// for(String item : items) { // foreach
		// 	if ("1".equals(item)) {
		// 		items.remove(item);
		// 	}
		// }

		Iterator itr = items.iterator();
		while(itr.hasNext()) {
			if (itr.next().equals("1")) {
				itr.remove();
			}
		}

		System.out.println(items);
	}
}
