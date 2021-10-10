import Box from '@mui/material/Box';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import { useEffect, useState } from 'react';
import TabLabel from './TabLabel';
import { getColor, FadingTab } from './FadingTab';
import { useSelector } from 'react-redux';
import { combatState } from '../../state/selectors';
import CombatSheet from '../CharacterSheet/CombatSheet';

const sorted = (characters) => {
  return [...characters].sort((a, b) => {
    return b.initiative - a.initiative;
  });
}

const firstInInitiative = (characters) => {
  const list = sorted(characters);
  return list.length === 0 ? 0 : list[0].id;
}

const CT_OLD = () => {
  const { combatants } = useSelector(combatState);
  const [characters, setCharacters] = useState(combatants);
  const [tabChangeAttempt, setTabChangeAttempt] = useState();
  const [selectedTab, setSelectedTab] = useState(firstInInitiative(characters));

  const handleInitiativeChange = (id, initiative) => {
    setCharacters(characters.map(c => {
      if (c.id === id) c.initiative = initiative;
      return c;
    }));
  };

  const handleCloseTab = (id) => {
    if (selectedTab === id) { // if selected tab is the one, that's being closed
      const ids = sorted(characters).map(c => c.id);
      const nextId = ids[ids.indexOf(id) + 1] !== undefined ? ids[ids.indexOf(id) + 1] : ids[ids.indexOf(id) - 1]
      setSelectedTab(nextId); // switch to tab to the right of closed tab – or to the left, if there are no tabs to the right
    }
    setCharacters(characters.filter(c => c.id !== id));
  }

  const handleSelectedTabChange = (event, newValue) => { // close button also selects tab,
    setTabChangeAttempt(newValue); // so each tab select only attempts to change tab
  };
  
  useEffect(() => { // and useEffect checks, if tabChangeAttempt is a non-closed tab
    if (characters.map(c => c.id).includes(tabChangeAttempt)) {
      setSelectedTab(tabChangeAttempt);
    }
  }, [tabChangeAttempt])

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={selectedTab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList
            // TabIndicatorProps={{ style: { background: "firebrick" } }}
            variant="scrollable"
            scrollButtons="auto"
            onChange={handleSelectedTabChange}>
              {sorted(characters).map(character =>
                <FadingTab
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
                <div className="flex-row-80">
                  <div className="flex-col">
                    <CombatSheet monster={character} />
                  </div>
                </div>
            </TabPanel>)}
      </TabContext>
    </Box>
  );
}

export default CT_OLD;