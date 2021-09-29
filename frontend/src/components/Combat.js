import Box from '@mui/material/Box';
import Tab from '@mui/material/Tab';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import { useState } from 'react';
import { Button, TextField } from '@mui/material';
import TabLabel from './CombatTabs/TabLabel';

const mockCharacters = [{
    name: "Kresentas",
    init: 1
  }, {
    name: "Negua",
    init: 5,
  }, {
    name: "Uranas",
    init: 10
  }]

const CombatTabs = () => {
  const [selectedTab, setSelectedTab] = useState('1');
  const [characters, setCharacters] = useState(mockCharacters);

  const handleChange = (event, newValue) => {
    setSelectedTab(newValue);
  };

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={selectedTab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleChange} aria-label="lab API tabs example">
            {characters.map(character =>
              <Tab label={<TabLabel
                name={character.name}
                init={character.init}/>} value={character.init}></Tab>)}
          </TabList>
        </Box>
          {characters.map(character =>
            <TabPanel value={character.init}>{character.name}</TabPanel>)}
      </TabContext>
    </Box>
  );
}

export default CombatTabs;