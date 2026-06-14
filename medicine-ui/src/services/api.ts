import axios from "axios";
import { toast } from "react-toastify";
import { Medicine } from "../types/types";

const API_URL = process.env.REACT_APP_API_URL as string;

export const api = axios.create({
  baseURL: API_URL
});

// Generic error handler
const handleError = (error: any) => {
  const response = error?.response;

  if (!response) {
    toast.error("Network error");
    return;
  }

  const data = response.data;
  const status = response.status;

  // ✅ 1. Handle ARRAY response
  if (Array.isArray(data)) {
    data.forEach((msg: string) => toast.error(msg));
    return;
  }

  // ✅ 2. Handle validation object
  if (data?.errors) {
    const messages: string[] = [];

    Object.keys(data.errors).forEach((field) => {
      const cleanField = field.replace("$.", "");

      if (cleanField === "expiryDate") {
        messages.push("Please check expiry date");
      } else if (cleanField === "med") {
        messages.push("Medicine name is required");
      } else {
        data.errors[field].forEach((msg: string) =>
          messages.push(msg)
        );
      }
    });

    toast.error(messages.join(" | "));
    return;
  }

  // ✅ 3. Handle status codes
  if (status === 404) {
    toast.error("Inventory not found");
    return;
  }

  // ✅ 4. Handle title/message fallback
  if (data?.title) {
    toast.error(data.title);
    return;
  }

  // ✅ fallback
  toast.error("Something went wrong");
};


// API methods
export const getMedicines = async (search = ""): Promise<Medicine[]> => {
  try {
    const res = await api.get(`?search=${search}`);
    return res.data;
  } catch (err) {
    handleError(err);
    return [];
  }
};

export const addMedicine = async (data: Medicine) => {
  try {
    await api.post("", data);
    toast.success("Medicine added successfully");
  } catch (err) {
    handleError(err);
  }
};

export const sellMedicine = async (id: number) => {
  try {
    await api.post(`/sell/${id}?qty=1`);
    toast.success("Sold successfully");
  } catch (err) {
    handleError(err);
  }
};