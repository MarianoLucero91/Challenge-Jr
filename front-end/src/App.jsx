import { Routes, Route } from "react-router-dom";
import { Layout } from './layout/Layout'
import { AltaPoliza } from "./pages/AltaPoliza";
import { ListaCoberturas } from "./pages/ListaCoberturas";
import { ListaPolizas } from "./pages/ListaPolizas";

function App() {

  return <Layout>
    <Routes>
      <Route path="/polizas" element={<ListaPolizas></ListaPolizas>}></Route>
      <Route path="/alta-poliza" element={<AltaPoliza></AltaPoliza>}></Route>
      <Route path="/coberturas" element={<ListaCoberturas></ListaCoberturas>}></Route>
    </Routes>
  </Layout>
}

export default App
