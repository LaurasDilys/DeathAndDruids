import { Button, Fab, TextField } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import { useEffect, useState } from "react";

const TabLabel = ({ id, name, init, onInitiativeChange, onClose }) => {
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
    <div className="tab-label">
      <span style={{paddingLeft: 15, paddingRight: 30}}>{name}</span>
      <TextField
        value={initiative}
        onChange={handleChange}
        size="small"
        style = {{width: 50}}>
      </TextField>
      <Button disableRipple onClick={onClick}><CloseIcon /></Button>
    </div>
  );
}

export default TabLabel;