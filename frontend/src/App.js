import './App.css';
import { BrowserRouter as Router, Switch, Redirect, Route, useLocation } from 'react-router-dom';
import Routes from './Routes';
import SideNav from './components/SideNav/SideNav';

const SideNavRenderer = () => {
  let location = useLocation();

  return Routes.map(r => r.path).includes(location.pathname)
    && <SideNav routes={Routes} />
}

const App = () => {
  return (
    <Router>
      <SideNavRenderer />
      <Switch>
        {Routes.map(({ path, getComponent }, index) => <Route
          key={index}
          exact={path === "/"}
          path={path}
          component={getComponent()} />)}
        <Redirect from="*" to="/" />
      </Switch>
    </Router>
  );
}

export default App;
