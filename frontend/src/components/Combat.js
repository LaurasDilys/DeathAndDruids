import Box from '@mui/material/Box';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import { useState } from 'react';
import TabLabel from './CombatTabs/TabLabel';
import { getColor, StyledTab } from './CombatTabs/StyledTab';
import { Tab } from '@mui/material';

const mockCharacters = [{
  id: 1,
  name: "Kresentas",
  initiative: 1,
  hp: 1,
  maxHp: 11
}, {
  id: 2,
  name: "Negua",
  initiative: 2,
  hp: 1,
  maxHp: 10
}, {
  id: 3,
  name: "Uranas",
  initiative: 4,
  hp: 2,
  maxHp: 10
}, {
  id: 4,
  name: "Kresentas",
  initiative: 6,
  hp: 4,
  maxHp: 10
}, {
  id: 5,
  name: "Negua",
  initiative: 8,
  hp: 6,
  maxHp: 10
}, {
  id: 6,
  name: "Uranas",
  initiative: 10,
  hp: 8,
  maxHp: 10
}]

const CombatTabs = () => {
  const [selectedTab, setSelectedTab] = useState();
  const [characters, setCharacters] = useState(mockCharacters);

  const sorted = (characters) => {
    return characters.sort((a, b) => {
      return b.initiative - a.initiative;
    });
  }

  const handleSelectedTabChange = (event, newValue) => {
    setSelectedTab(newValue);
  };

  const handleInitiativeChange = (id, initiative) => {
    setCharacters(characters.map(c => {
      console.log();
      if (c.id === id) c.initiative = initiative;
      return c;
    }));
  };

  const handleCloseTab = (id) => {
    setCharacters(characters.filter(c => c.id !== id));
  }

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={selectedTab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList onChange={handleSelectedTabChange} aria-label="lab API tabs example">
            {sorted(characters).map(character =>
              <Tab
                style={getColor(character.hp / character.maxHp)}
                key={character.id}
                value={character.id}
                label={<TabLabel
                  id={character.id}
                  name={character.name}
                  init={character.initiative}
                  onInitiativeChange={handleInitiativeChange}
                  onClose={handleCloseTab}/>}/>)}
          </TabList>
        </Box>
          {characters.map(character =>
            <TabPanel
              key={character.id}
              value={character.id}>
                {character.name}{character.initiative}
            </TabPanel>)}
      </TabContext>
    </Box>
  );
}

export default CombatTabs;