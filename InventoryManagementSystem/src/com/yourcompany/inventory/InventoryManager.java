package com.yourcompany.inventory;

import java.util.HashMap;
import java.util.Map;

public class InventoryManager {
    private Map<String, Product> inventory;

    public InventoryManager() {
        this.inventory = new HashMap<>();
    }

    public void addProduct(String name, int stock) {
        Product product = new Product(name, stock);
        inventory.put(name, product);
    }

    public void updateProductStock(String name, int newStock) {
        Product product = inventory.get(name);
        if (product != null) {
            product.setStock(newStock);
        }
    }

    public void removeProduct(String name) {
        inventory.remove(name);
    }

    public int getProductStock(String name) {
        Product product = inventory.get(name);
        return (product != null) ? product.getStock() : 0;
    }
}
