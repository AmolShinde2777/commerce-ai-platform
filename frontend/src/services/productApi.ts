export interface Product {
  id: string;
  name: string;
  sku: string;
  description: string;
  price: number;
  quantityInStock: number;
  categoryName: string;
  imageUrl: string;
  status: string;
}

const API_BASE_URL = 'http://localhost:5251';

export async function getProducts(): Promise<Product[]> {
  const response = await fetch(`${API_BASE_URL}/api/products`);

  if (!response.ok) {
    throw new Error('Failed to fetch products');
  }

  return response.json();
}