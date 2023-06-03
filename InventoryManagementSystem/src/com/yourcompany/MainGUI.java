package com.yourcompany;

import com.yourcompany.inventory.InventoryManager;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MainGUI extends JFrame {
    private InventoryManager inventoryManager;
    private JTextField productNameField;
    private JTextField productPriceField;
    private JTextField productStockField;
    private JTextArea inventoryArea;

    public MainGUI() {
        inventoryManager = new InventoryManager();

        // Set up the main frame
        setTitle("Inventory Management");
        setSize(400, 400);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout());

        // Create the input panel
        JPanel inputPanel = new JPanel();
        inputPanel.setLayout(new GridLayout(4, 2));
        inputPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        // Product Name
        JLabel productNameLabel = new JLabel("Product Name:");
        productNameField = new JTextField();
        inputPanel.add(productNameLabel);
        inputPanel.add(productNameField);

        // Product Price
        JLabel productPriceLabel = new JLabel("Product Price:");
        productPriceField = new JTextField();
        inputPanel.add(productPriceLabel);
        inputPanel.add(productPriceField);

        // Product Stock
        JLabel productStockLabel = new JLabel("Product Stock:");
        productStockField = new JTextField();
        inputPanel.add(productStockLabel);
        inputPanel.add(productStockField);

        // Add Button
        JButton addButton = new JButton("Add Product");
        addButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                String name = productNameField.getText();
                double price = Double.parseDouble(productPriceField.getText());
                int stock = Integer.parseInt(productStockField.getText());
                inventoryManager.addProduct(name, price, stock);
                updateInventoryArea();
                clearInputFields();
            }
        });
        inputPanel.add(addButton);

        // Remove Button
        JButton removeButton = new JButton("Remove Product");
        removeButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                String name = productNameField.getText();
                inventoryManager.removeProduct(name);
                updateInventoryArea();
                clearInputFields();
            }
        });
        inputPanel.add(removeButton);

        // Create the inventory area
        inventoryArea = new JTextArea();
        inventoryArea.setEditable(false);
        inventoryArea.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        // Add components to the main frame
        add(inputPanel, BorderLayout.NORTH);
        add(new JScrollPane(inventoryArea), BorderLayout.CENTER);

        // Show the main frame
        setVisible(true);
    }

    private void updateInventoryArea() {
        StringBuilder sb = new StringBuilder();
        for (String productName : inventoryManager.getInventory().keySet()) {
            int stock = inventoryManager.getProductStock(productName);
            double price = inventoryManager.getProductPrice(productName);
            sb.append(productName).append(" (Price: $").append(price).append(", Stock: ").append(stock).append(")\n");
        }
        inventoryArea.setText(sb.toString());
    }

    private void clearInputFields() {
        productNameField.setText("");
        productPriceField.setText("");
        productStockField.setText("");
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                new MainGUI();
            }
        });
    }
}
