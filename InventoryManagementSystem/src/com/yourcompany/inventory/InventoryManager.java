package com.yourcompany.inventory;

import java.util.HashMap;
import java.util.Map;

public class InventoryManager {
    private Map<String, Product> inventory;

    public InventoryManager() {
        inventory = new HashMap<>();
    }

    public void addProduct(String name, double price, int stock) {
        Product product = new Product(name, price, stock);
        inventory.put(name, product);
    }

    public void updateProductStock(String name, int newStock) {
        if (inventory.containsKey(name)) {
            Product product = inventory.get(name);
            product.setStock(newStock);
        }
    }

    public void removeProduct(String name) {
        inventory.remove(name);
    }

    public int getProductStock(String name) {
        Product product = inventory.get(name);
        if (product != null) {
            return product.getStock();
        }
        return 0;
    }

    public double getProductPrice(String name) {
        Product product = inventory.get(name);
        if (product != null) {
            return product.getPrice();
        }
        return 0.0;
    }

    public boolean checkProductAvailability(String name, int quantity) {
        Product product = inventory.get(name);
        if (product != null) {
            return product.getStock() >= quantity;
        }
        return false;
    }

    public void reduceProductStock(String name, int quantity) {
        Product product = inventory.get(name);
        if (product != null) {
            int currentStock = product.getStock();
            product.setStock(currentStock - quantity);
        }
    }

    public Map<String, Product> getInventory() {
        return inventory;
    }
}
