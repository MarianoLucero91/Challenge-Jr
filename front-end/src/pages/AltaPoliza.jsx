import { useState, useEffect } from "react";
import { Button, MenuItem, Select, TextField } from "@mui/material"

function updatePolizaCoberturaByIndex(polizaCoberturas, index, coberturaId, montoAsegurado) {
    const copy = [...polizaCoberturas]
    const toUpdate = copy[index]
    toUpdate.coberturaId = coberturaId
    toUpdate.montoAsegurado = montoAsegurado

    return copy
}

function crearPoliza(nombre, coberturas) {
    const nuevaPoliza = {
        Nombre: nombre,
        PolizasCoberturas: coberturas
    }
    
    return fetch(`http://localhost:5073/api/polizas`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(nuevaPoliza) })
        .then(response => response.json())
        .catch(() => alert("Hubo un problema al dar de alta la poliza. Intente nuevamente."))
}


export function AltaPoliza() {
    const [listaCoberturas, setListaCoberturas] = useState([])
    const [nombre, setNombre] = useState("")
    const [polizaCoberturas, setPolizaCoberturas] = useState([])

    useEffect(() => {
        fetch("http://localhost:5073/api/coberturas").then(response => response.json()).then(data => setListaCoberturas(data))
    }, [])

    return <form onSubmit={(e) => {
            e.preventDefault();
            crearPoliza(nombre, polizaCoberturas)
        }}>
        <TextField label="Nombre" value={nombre} onChange={e => setNombre(e.target.value)} />
        <Button onClick={() => setPolizaCoberturas(pc => [...pc, { coberturaId: listaCoberturas[0].id, montoAsegurado: 0 }])}>Agregar Cobertura</Button>
        {polizaCoberturas.map((pc, index) => 
            <>
                <Select label="Cobertura" value={pc.coberturaId} onChange={e => setPolizaCoberturas(foo => updatePolizaCoberturaByIndex(foo, index, e.target.value, pc.montoAsegurado))}>{listaCoberturas.map(c => <MenuItem value={c.id}>{c.nombre}</MenuItem>)}</Select>
                <TextField type="number" label="Monto Asegurado" value={pc.montoAsegurado} onChange={e => setPolizaCoberturas(foo => updatePolizaCoberturaByIndex(foo, index, pc.coberturaId, e.target.value))} />
            </>
        )}
        <Button type="submit">Agregar</Button>
    </form>
}