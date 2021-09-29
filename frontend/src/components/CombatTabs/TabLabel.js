import { Button, TextField } from "@mui/material";
import { useEffect, useState } from "react";

const TabLabel = ({ /*hp,*/ id, name, init, onInitiativeChange, onClose }) => {
  const [initiative, setInitiative] = useState(init);

  const handleChange = event => {
    const value = event.target.value;
    setInitiative(value);
  }

  useEffect(() => {
    onInitiativeChange(id, initiative);
  }, [initiative])

  const onClick = event => {
    onClose(id);
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
      <Button onClick={onClick}>x</Button>
    </div>
  );
}

export default TabLabel;