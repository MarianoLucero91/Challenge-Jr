import { Typography, Card, CardContent, CardActions, Button, TextField, Box } from "@mui/material";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";

function deletePoliza(id) {
    return fetch(`http://localhost:5073/api/polizas/${id}`, { method: "DELETE" }).catch(() => alert("Hubo un problema al borrar la poliza. Intente nuevamente."))
}

function Poliza({ poliza }) {
    const montoTotal = poliza.polizasCoberturas.reduce((acc, current) => acc + current.montoAsegurado, 0)

    return <Card sx={{ minWidth: 275, mt: 2, mb: 2 }} variant="outlined">
        <CardContent>
            <Typography>Nombre: {poliza.nombre}</Typography>
            <Typography>Monto Total Asegurado: ${montoTotal}</Typography>
        </CardContent>
        <CardActions>
            <Button>Editar</Button>
            <Button onClick={() => deletePoliza(poliza.id)}>Borrar</Button>
        </CardActions>
    </Card>
}

export function ListaPolizas() {
    const [polizas, setPolizas] = useState([])

    useEffect(() => {
        fetch("http://localhost:5073/api/polizas").then(response => response.json()).then(data => setPolizas(data))
    }, [])

    return <>
        <Typography variant="h3">Lista de Polizas</Typography>
        <Link to="/alta-poliza">
            <Button>Crear nueva Poliza</Button>
        </Link>
        {polizas.length === 0 ? <Typography>No hay polizas para mostrar</Typography> : polizas.map(poliza => <Poliza key={poliza.id} poliza={poliza}></Poliza>)}
    </>
}

