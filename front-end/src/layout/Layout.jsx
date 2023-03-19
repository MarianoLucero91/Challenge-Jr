import { Container, Typography } from "@mui/material";

export function Layout({ children }) {
    return <main>
        <Container sx={{ minHeight: 100, display: "flex", justifyContent: "center", alignItems: "center", borderBottom: "1px solid black" }}>
            <Typography variant="h2" fontWeight="bold">Admin Polizas</Typography>
        </Container>
        <Container maxWidth="md">{children}</Container>
    </main>
}