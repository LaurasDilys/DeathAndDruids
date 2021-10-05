import { TextField } from "@mui/material";
import { useEffect, useState } from "react"

const NumberField = ({ name, value }) => {
  const [state, setState] = useState(value);

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    setState(event.target.value);
  }

  return(
    <TextField
      label={name}
      value={state}
      type="number"
      InputLabelProps={{
        shrink: true,
      }}
      onChange={handleChange}
    />
  );
};

export default NumberField;