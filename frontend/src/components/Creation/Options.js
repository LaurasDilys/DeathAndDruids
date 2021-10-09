import { Button, FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { withStyles } from '@mui/styles';
import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { newMonster, openMonster } from '../../state/actions/creationThunk';
import { monstersState } from '../../state/selectors/creationSelectors';

const styles = {
  select: {
    paddingLeft: 20,
    textAlign: "left"
  }
};

const Options = ({ classes }) => {
  const { monsters } = useSelector(monstersState);
  const [selected, setSelected] = useState();
  const dispatch = useDispatch();

  const handleNew = () => {
    dispatch(newMonster());
  }

  const handleOpen = event => {
    setSelected(event.target.value);
    const id = monsters.find(x => x.name === event.target.value).id;
    dispatch(openMonster(id));
  };
  
  return (
    <div className="opt-items">
      <Button onClick={handleNew}>New</Button>
      {monsters.length > 0 &&
      <FormControl sx={{ m: 1, width: "160px" }} error>
        <InputLabel>Open</InputLabel>
          <Select
            inputProps={{ classes: { select: classes.select } }}
            value={selected}
            label="Open"
            onChange={handleOpen}
          >
          {[...monsters].sort((a, b) => a.name.localeCompare(b.name))
          .map(monster => <MenuItem key={monster.name} value={monster.name}>{monster.name}</MenuItem>)}
        </Select>
      </FormControl>}
    </div>
  );
};

export default withStyles(styles)(Options);