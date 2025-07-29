import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import { Home } from './pages/Home';
import { Pedido } from './pages/Pedido';
import { Confirmacao } from './pages/Confirmacao';
import { ScrollToTop } from './components/ScrollToTop';
import { SkeletonTheme } from 'react-loading-skeleton';
import { Administrador } from './pages/administrador';

function App() {
  return (

    <SkeletonTheme baseColor='#313131' highlightColor='#525252'>

      <BrowserRouter>
        <ScrollToTop />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/pedido" element={<Pedido />} />
          <Route path="/confirmacao" element={<Confirmacao />} />
          <Route path="/administrador" element={<Administrador />} />

        </Routes>

      </BrowserRouter>

    </SkeletonTheme>

  );
}

export default App;
