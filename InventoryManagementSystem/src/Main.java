import com.yourcompany.inventory.InventoryManager;

public class Main {
    public static void main(String[] args) {
        InventoryManager inventoryManager = new InventoryManager();

        // Add products to the inventory
        inventoryManager.addProduct("Product A", 10);
        inventoryManager.addProduct("Product B", 20);
        inventoryManager.addProduct("Product C", 30);

        // Update product stock
        inventoryManager.updateProductStock("Product A", 15);

        // Remove a product
        inventoryManager.removeProduct("Product B");

        // Get product stock
        int stock = inventoryManager.getProductStock("Product C");
        System.out.println("Product C stock: " + stock);
    }
}
