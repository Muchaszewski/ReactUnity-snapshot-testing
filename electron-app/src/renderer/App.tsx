import { MemoryRouter as Router, Routes, Route } from 'react-router-dom';
import icon from '../../assets/icon.svg';
import './App.css';

window.electron.ipcRenderer.once('screenshot', (arg) => {
  // eslint-disable-next-line no-console
  console.log(arg);
});

const Hello = () => {
  return (
    <div>
      <h1>Hello World</h1>
      <button onClick={() => window.electron.ipcRenderer.sendMessage('screenshot', ['ping'])}>Send IPC</button>
    </div>
  );
};

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Hello />} />
      </Routes>
    </Router>
  );
}
