import { Typography, Card, CardContent, CardActions, Button, TextField, Box } from "@mui/material";
import { useState, useEffect } from "react";

function addCobertura(nombre) {
    return fetch(`http://localhost:5073/api/coberturas`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify({ Nombre: nombre }) })
        .then(response => response.json())
        .catch(() => alert("Hubo un problema al agregar la cobertura. Intente nuevamente."))
}

function deleteCobertura(id) {
    return fetch(`http://localhost:5073/api/coberturas/${id}`, { method: "DELETE" }).catch(() => alert("Hubo un problema al borrar la cobertura. Intente nuevamente."))
}

function Cobertura({ cobertura }) {
    return <Card sx={{ minWidth: 275, mt: 2, mb: 2 }} variant="outlined">
        <CardContent>
            <Typography >{cobertura.nombre}</Typography>
        </CardContent>
        <CardActions>
            <Button>Editar</Button>
            <Button onClick={() => deleteCobertura(cobertura.id)}>Borrar</Button>
        </CardActions>
    </Card>
}

function AddCobertura() {
    const [nombre, setNombre] = useState("")

    return <Box mt={3} mb={3}>
        <form onSubmit={(e) => {
            e.preventDefault();
            addCobertura(nombre).then(() => setNombre(""))
        }}>
            <TextField label="Nombre" value={nombre} onChange={e => setNombre(e.target.value)} />
            <Button type="submit">Agregar</Button>
        </form>
    </Box>
}

export function ListaCoberturas() {
    const [coberturas, setCoberturas] = useState([])

    useEffect(() => {
        fetch("http://localhost:5073/api/coberturas").then(response => response.json()).then(data => setCoberturas(data))
    }, [])

    return <>
        <Typography variant="h3">Lista de Coberturas</Typography>
        <AddCobertura />
        {coberturas.length === 0 ? <Typography>No hay coberturas para mostrar</Typography> : coberturas.map(cobertura => <Cobertura key={cobertura.id} cobertura={cobertura}></Cobertura>)}
    </>
}

