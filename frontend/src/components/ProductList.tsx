import { useEffect, useState } from 'react';
import { getProducts, type Product } from '../services/productApi';

function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    async function loadProducts() {
      try {
        const data = await getProducts();
        setProducts(data);
      } catch (err) {
        setError('Unable to load products.');
        console.error(err);
      } finally {
        setLoading(false);
      }
    }

    loadProducts();
  }, []);

  if (loading) {
    return <p>Loading products...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  if (products.length === 0) {
    return <p>No products found.</p>;
  }

  return (
    <div className="product-grid">
      {products.map((product) => (
        <div className="product-card" key={product.id}>
          <div className="product-card-content">
            <h3>{product.name}</h3>

            <p className="product-sku">
              SKU: {product.sku}
            </p>

            <p>{product.description}</p>

            <div className="product-details">
              <strong>${product.price.toFixed(2)}</strong>

              <span>
                Stock: {product.quantityInStock}
              </span>
            </div>

            <span className="product-category">
              {product.categoryName}
            </span>
          </div>
        </div>
      ))}
    </div>
  );
}

export default ProductList;