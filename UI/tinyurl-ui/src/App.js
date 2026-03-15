import React from "react";
import Header from "./components/Header";
import UrlGeneratorCard from "./components/UrlGeneratorCard";
import ShortUrlResult from  "./components/ShortUrlResult";
import PublicUrls from  "./components/PublicUrls";
import "./App.css";
function App() {
  return (
  <div>
      <Header/>
      <UrlGeneratorCard />
      <ShortUrlResult/> 
      <PublicUrls/> 
    </div> 
     /*<div className="container mt-5">
      <h1 className="text-primary">Tiny URL</h1>
      <button className="btn btn-success">Test Button</button>
      </div>*/
  );
}

export default App;
