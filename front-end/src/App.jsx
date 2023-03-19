import { Routes, Route } from "react-router-dom";
import { Layout } from './layout/Layout'
import { Coberturas } from "./pages/Coberturas";
import { Polizas } from "./pages/Polizas";

function App() {

  return <Layout>
    <Routes>
      <Route path="/polizas" element={<Polizas></Polizas>}></Route>
      <Route path="/coberturas" element={<Coberturas></Coberturas>}></Route>
    </Routes>
  </Layout>
}

export default App
