import { Chip, Divider, Fab, ListItem, ListItemAvatar, ListItemText, Tooltip } from '@mui/material';
import RemoveIcon from '@mui/icons-material/Remove';
import AddIcon from '@mui/icons-material/Add';
import { useState } from "react";

const CombatantListItem = ({ id, name, onSelectAmount, disabled }) => {
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
    <Tooltip title={disabled ? "Please close creation in order to use this monster in combat." : ""}>
      <div>
        <ListItem>
          <ListItemAvatar>
            <Fab size="small" color="primary" onClick={onRemove} disabled={disabled}>
              <RemoveIcon/>
            </Fab>
          </ListItemAvatar>
          <ListItemAvatar>
            <Chip label={amount} color="primary" variant="outlined" style={{width: 41}} />
          </ListItemAvatar>
          <ListItemAvatar>
            <Fab size="small" color="primary" onClick={onAdd} disabled={disabled}>
              <AddIcon />
            </Fab>
          </ListItemAvatar>
          <ListItemText primary={name} />
        </ListItem>
        <Divider />
      </div>
    </Tooltip>
  );
};

export default CombatantListItem;