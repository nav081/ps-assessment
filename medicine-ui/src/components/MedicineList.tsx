import React, { useEffect, useState } from "react";
import {
  Box,
  CircularProgress,
  TextField,
  Button,
  Card,
  CardContent,
  Typography,
  useTheme,
  useMediaQuery
} from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { getMedicines, sellMedicine } from "../services/api";
import { Medicine } from "../types/types";
import SalesDialog from "../components/SalesDialog";

interface Props {
  reload: boolean;
}

const MedicineList: React.FC<Props> = ({ reload }) => {
  const [data, setData] = useState<Medicine[]>([]);
  const [loading, setLoading] = useState(false);
  const [search, setSearch] = useState("");
  const [salesDialogOpen, setSalesDialogOpen] = useState(false);

  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("sm"));

  const fetchData = async () => {
    setLoading(true);
    const res = await getMedicines(search);
    setData(res);
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, [reload]);

  const handleSell = async (id: number) => {
    setLoading(true);
    await sellMedicine(id);
    await fetchData();
    setLoading(false);
  };

  // ✅ STATUS LOGIC
  const getStatus = (m: Medicine) => {
    const expiry = new Date(m.expiryDate);
    const today = new Date();

    const diff =
      (expiry.getTime() - today.getTime()) / (1000 * 60 * 60 * 24);

    if (diff < 30) return "expired"; // 🔴 priority
    if (m.quantity < 10) return "low"; // 🟡
    return "ok";
  };

  // ✅ SORT BY EXPIRY
  const sortedData = [...data].sort(
    (a, b) =>
      new Date(a.expiryDate).getTime() -
      new Date(b.expiryDate).getTime()
  );

  // ✅ GRID COLUMNS
  const columns: GridColDef[] = [
    { field: "fullName", headerName: "Name", flex: 1 },

    {
      field: "expiryDate",
      headerName: "Expiry",
      flex: 1,
      renderCell: (params) => params.value?.split("T")[0]
    },

    { field: "quantity", headerName: "Qty", flex: 1 },

    {
      field: "price",
      headerName: "Price",
      flex: 1,
      renderCell: (params) => `₹ ${params.value}`
    },

    { field: "brand", headerName: "Brand", flex: 1 },

    {
      field: "action",
      headerName: "Action",
      renderCell: (params) => (
        <Button
          variant="contained"
          size="small"
          onClick={() => handleSell(params.row.id)}
        >
          Sell
        </Button>
      )
    }
  ];

  return (
    <Box sx={{ p: 2 }}>

      {/* ✅ HEADER */}
      <Typography
        variant="h5"
        sx={{
          mb: 2,
          fontWeight: "bold",
          borderBottom: "2px solid #1976d2",
          pb: 1
        }}
      >
        Medicines Inventory
      </Typography>

      {/* ✅ LEGEND */}
      <Box sx={{ display: "flex", gap: 2, mb: 2 }}>
        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
          <Box sx={{ width: 20, height: 20, background: "#ffcccc" }} />
          <Typography variant="body2">Expiry &lt; 30 days</Typography>
        </Box>

        <Box sx={{ display: "flex", alignItems: "center", gap: 1 }}>
          <Box sx={{ width: 20, height: 20, background: "#fff3cd" }} />
          <Typography variant="body2">Low Stock (&lt;10)</Typography>
        </Box>
      </Box>

      {/* ✅ SEARCH */}
      <Box sx={{ display: "flex", gap: 2, mb: 2 }}>
        <TextField
          fullWidth
          label="Search Medicine"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <Button variant="contained" onClick={fetchData}>
          Search
        </Button>
      </Box>
      
      <Box sx={{ display: "flex", justifyContent: "space-between", mb: 2 }}>
        <Typography variant="h5">Medicines Inventory</Typography>
        <Button variant="outlined" onClick={() => setSalesDialogOpen(true)}>
          View Sales History
        </Button>
      </Box>


      {/* ✅ LOADER */}
      {loading ? (
        <Box sx={{ textAlign: "center", mt: 5 }}>
          <CircularProgress />
        </Box>
      ) : (
        <>
          {/* ✅ MOBILE VIEW */}
          {isMobile ? (
            <Box sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
              {sortedData.map((m) => {
                const status = getStatus(m);

                return (
                  <Card
                    key={m.id}
                    sx={{
                      backgroundColor:
                        status === "expired"
                          ? "#ffcccc"
                          : status === "low"
                          ? "#fff3cd"
                          : "#ffffff"
                    }}
                  >
                    <CardContent>
                      <Typography variant="h6">{m.fullName}</Typography>
                      <Typography color="text.secondary">
                        {m.brand}
                      </Typography>
                      <Typography>Qty: {m.quantity}</Typography>
                      <Typography>Price: ₹{m.price}</Typography>
                      <Typography>
                        Expiry: {m.expiryDate?.split("T")[0]}
                      </Typography>

                      <Button
                        variant="contained"
                        fullWidth
                        sx={{ mt: 2 }}
                        onClick={() => handleSell(m.id)}
                      >
                        Sell
                      </Button>
                    </CardContent>
                  </Card>
                );
              })}
            </Box>
          ) : (
            /* ✅ DESKTOP GRID */
            <DataGrid
              rows={sortedData}
              columns={columns}
              autoHeight
              sx={{
                "& .MuiDataGrid-columnHeaders": {
                  backgroundColor: "#1976d2",
                  color: "#fff",
                  fontWeight: "bold"
                }
              }}
              getRowClassName={(params) => {
                const status = getStatus(params.row);

                if (status === "expired") return "expired-row";
                if (status === "low") return "low-row";
                return "";
              }}
            />
          )}
        </>
      )}

      {/* ✅ ROW COLORS */}
      <style>
        {`
          .expired-row {
            background-color: #ffcccc !important;
          }

          .low-row {
            background-color: #fff3cd !important;
          }
        `}
      </style>
      
    <SalesDialog
      open={salesDialogOpen}
      onClose={() => setSalesDialogOpen(false)}
    />

    </Box>
    
  );
};

export default MedicineList;