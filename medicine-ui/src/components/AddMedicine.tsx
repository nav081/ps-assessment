import React, { useState } from "react";
import {
  TextField,
  Button,
  Card,
  CardContent,
  Box,
  Typography
} from "@mui/material";
import { addMedicine } from "../services/api";
import { Medicine,MedicineForm } from "../types/types";
interface Props {
  onSuccess: () => void;
}

const AddMedicine: React.FC<Props> = ({ onSuccess }) => {
  const [form, setForm] = useState({
    fullName: "",
    notes: "",
    expiryDate: "",
    quantity: "",
    price: "",
    brand: ""
  });

  const [errors, setErrors] = useState<any>({});

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });

    // ✅ clear error when user types
    setErrors({ ...errors, [e.target.name]: "" });
  };

  // ✅ VALIDATION FUNCTION
  const validate = () => {
    const newErrors: any = {};

    if (!form.fullName.trim())
      newErrors.fullName = "Medicine name is required";

    if (!form.brand.trim())
      newErrors.brand = "Brand is required";

    if (!form.expiryDate)
      newErrors.expiryDate = "Expiry date is required";

    if (!form.quantity || Number(form.quantity) <= 0)
      newErrors.quantity = "Enter valid quantity";

    if (!form.price || Number(form.price) <= 0)
      newErrors.price = "Enter valid price";

    setErrors(newErrors);

    return Object.keys(newErrors).length === 0;
  };

  const submit = async () => {
    if (!validate()) return; // ✅ stop API call if invalid

    const formData = new MedicineForm( form.fullName, form.notes, form.expiryDate, Number(form.quantity), Number(form.price), form.brand);
    await addMedicine(formData);

    onSuccess();

    setForm({
      fullName: "",
      notes: "",
      expiryDate: "",
      quantity: "",
      price: "",
      brand: ""
    });

    setErrors({});
  };

  return (
    <Card sx={{ m: 2, maxWidth: 1000, mx: "auto" }}>
      <CardContent>
        <Typography variant="h6" mb={2}>
          Add Medicine
        </Typography>

        {/* ✅ Responsive layout */}
        <Box
          sx={{
            display: "grid",
            gridTemplateColumns: {
              xs: "1fr",
              sm: "1fr 1fr",
              md: "1fr 1fr 1fr"
            },
            gap: 2
          }}
        >
          {/* Name */}
          <TextField
            label="Medicine Name"
            name="fullName"
            value={form.fullName}
            onChange={handleChange}
            error={!!errors.fullName}
            helperText={errors.fullName}
            fullWidth
          />

          {/* Brand */}
          <TextField
            label="Brand"
            name="brand"
            value={form.brand}
            onChange={handleChange}
            error={!!errors.brand}
            helperText={errors.brand}
            fullWidth
          />

          {/* Expiry */}
          <TextField
            type="date"
            name="expiryDate"
            value={form.expiryDate}
            onChange={handleChange}
            error={!!errors.expiryDate}
            helperText={errors.expiryDate}
            fullWidth
          />

          {/* Quantity */}
          <TextField
            type="number"
            label="Quantity"
            name="quantity"
            value={form.quantity}
            onChange={handleChange}
            error={!!errors.quantity}
            helperText={errors.quantity}
            fullWidth
          />

          {/* Price */}
          <TextField
            type="number"
            label="Price"
            name="price"
            value={form.price}
            onChange={handleChange}
            error={!!errors.price}
            helperText={errors.price}
            fullWidth
          />

          {/* Notes (optional) */}
          <TextField
            label="Notes (optional)"
            name="notes"
            value={form.notes}
            onChange={handleChange}
            fullWidth
            multiline
            rows={2}
            sx={{ gridColumn: { md: "span 3" } }}
          />

          {/* Submit */}
          <Button
            variant="contained"
            fullWidth
            size="large"
            onClick={submit}
            sx={{ gridColumn: { md: "span 3" } }}
          >
            Add Medicine
          </Button>
        </Box>
      </CardContent>
    </Card>
  );
};

export default AddMedicine;