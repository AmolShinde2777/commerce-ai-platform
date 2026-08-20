import './App.css';
import ProductList from './components/ProductList';
import ChatPanel from './components/ChatPanel';

function App() {
  return (
    <div className="app">
      <header className="app-header">
        <h1>Commerce AI</h1>
        <p>AI-powered commerce platform</p>
      </header>

      <main className="app-content">
        <section className="products-section">
          <h2>Products</h2>

          <ProductList />
        </section>

        <section className="chat-section">
          <h2>AI Assistant</h2>

          <ChatPanel />
        </section>
      </main>
    </div>
  );
}

export default App;