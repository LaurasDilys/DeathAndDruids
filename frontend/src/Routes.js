import CombatTabs from './components/CombatTabs/CombatTabs';

const Routes = [
  {
    title: "Home",
    path: "/",
    getComponent: () => {return CombatTabs}
  },
  {
    title: "Creation",
    path: "/creation",
    getComponent: () => {return CombatTabs}
  },
  {
    title: "Combat",
    path: "/combat",
    getComponent: () => {return CombatTabs}
  },
  
]

export default Routes;