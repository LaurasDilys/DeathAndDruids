import './App.css';
import { BrowserRouter as Router, Switch, Route, useLocation } from 'react-router-dom';
import Routes from './Routes';
import SideNav from './components/SideNav/SideNav';
import { useDispatch } from 'react-redux';
import { setRoute } from './state/actions/locationThunk';

const LocationTracker = (props) => {
  const dispatch = useDispatch();
  const location = useLocation();

  dispatch(setRoute({
    route: location.pathname.slice(1)
  }));

  return props.children;
}

const App = () => {
  return (
    <Router>
      <LocationTracker>
        <SideNav routes={Routes} />
        <Switch>
          {Routes.map(({ path, getComponent }, index) => <Route
            key={index}
            exact={path === "/"}
            path={path}
            component={getComponent()} />)}
        </Switch>
      </LocationTracker>
    </Router>
  );
}

export default App;
