import { Fab } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import './Combat.css'

const Combat = () => {

  return (
    <div className="combat-selection-row">
      <div className="combat-selection-col" >
        <div className="combat-row">
          <Fab size="small" color="secondary" aria-label="add">
            <AddIcon />
          </Fab>
          <span>Test</span>
          <span>Test</span>
          <span>Test</span>
          <span>Test</span>
        </div>
      </div>
    </div>
  );
};

export default Combat;