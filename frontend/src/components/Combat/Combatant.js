import { Chip, Divider, Fab, ListItem, ListItemAvatar, ListItemText } from '@mui/material';
import RemoveIcon from '@mui/icons-material/Remove';
import AddIcon from '@mui/icons-material/Add';
import { useState } from "react";

const Combatant = ({ id, name, onSelectAmount }) => {
  const [amount, setAmount] = useState(0);

  const onAdd = () => {
    onSelectAmount({ id: id, amount: amount + 1 });
    setAmount(amount + 1);
  }

  const onRemove = () => {
    let num = amount;
    if (num > 0) {
      setAmount(num - 1);
      onSelectAmount({ id: id, amount: num - 1 });
    }
  }

  return (
    <>
      <ListItem>
        <ListItemAvatar>
          <Fab size="small" color="primary" onClick={onRemove}>
            <RemoveIcon/>
          </Fab>
        </ListItemAvatar>
        <ListItemAvatar>
          <Chip label={amount} color="primary" variant="outlined" style={{width: 41}} />
        </ListItemAvatar>
        <ListItemAvatar>
          <Fab size="small" color="primary" onClick={onAdd}>
            <AddIcon />
          </Fab>
        </ListItemAvatar>
        <ListItemText primary={name} />
      </ListItem>
      <Divider />
    </>
  );
};

export default Combatant;