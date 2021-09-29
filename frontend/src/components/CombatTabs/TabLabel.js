import { Button, TextField } from "@mui/material";
import { useState } from "react";

const TabLabel = ({ hp, name, init, onChange, onClose }) => {
  const [initiative, setInitiative] = useState(init);

  const handleChange = event => {
    const value = event.target.value;
    setInitiative(value);
  }

  return (
    <div>
      <span style={{paddingLeft: 15, paddingRight: 30}}>{name}</span>
      <TextField
        value={initiative}
        onChange={handleChange}
        size="small"
        style = {{width: 50}}>
      </TextField>
      <Button>x</Button>
    </div>
  );
}

export default TabLabel;