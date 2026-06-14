import React, { useEffect, useState } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  CircularProgress
} from "@mui/material";
import { getSales } from "../services/api";

interface Props {
  open: boolean;
  onClose: () => void;
}

const SalesDialog: React.FC<Props> = ({ open, onClose }) => {
  const [data, setData] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (open) {
      fetchSales();
    }
  }, [open]);

  const fetchSales = async () => {
    setLoading(true);
    const res = await getSales();
    setData(res || []);
    setLoading(false);
  };

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="md">
      <DialogTitle>Sales History</DialogTitle>

      <DialogContent>

        {loading ? (
          <CircularProgress />
        ) : (
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Medicine</TableCell>
                <TableCell>Quantity</TableCell>
                <TableCell>Price</TableCell>
                <TableCell>Date</TableCell>
              </TableRow>
            </TableHead>

            <TableBody>
              {data.map((s) => (
                <TableRow key={s.id}>
                  <TableCell>{s.medicineName}</TableCell>
                  <TableCell>{s.quantitySold}</TableCell>
                  <TableCell>₹ {s.price}</TableCell>
                  <TableCell>
                    {new Date(s.soldOn).toLocaleDateString()}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        )}

      </DialogContent>
    </Dialog>
  );
};

export default SalesDialog;