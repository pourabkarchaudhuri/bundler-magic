import com.yourcompany.inventory.InventoryManager;

public class Main {
    public static void main(String[] args) {
        InventoryManager inventoryManager = new InventoryManager();

        // Add products to the inventory
        inventoryManager.addProduct("Product A", 10.99, 10);
        inventoryManager.addProduct("Product B", 20.99, 20);
        inventoryManager.addProduct("Product C", 30.99, 30);

        // Update product stock
        inventoryManager.updateProductStock("Product A", 15);

        // Remove a product
        inventoryManager.removeProduct("Product B");

        // Get product stock and price
        int stock = inventoryManager.getProductStock("Product C");
        double price = inventoryManager.getProductPrice("Product C");
        System.out.println("Product C stock: " + stock);
        System.out.println("Product C price: $" + price);

        // Check product availability
        boolean isAvailable = inventoryManager.checkProductAvailability("Product C", 5);
        System.out.println("Product C is available: " + isAvailable);

        // Reduce product stock when purchased
        inventoryManager.reduceProductStock("Product C", 5);
        stock = inventoryManager.getProductStock("Product C");
        System.out.println("Product C stock after purchase: " + stock);
    }
}
