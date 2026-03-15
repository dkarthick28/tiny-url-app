import {BrowserRouter as Router,Routes,Route} from "react-router-dom";
import React,{useEffect, useState} from "react";
import Header from "./components/Header";
import UrlGeneratorCard from "./components/UrlGeneratorCard";
import ShortUrlResult from  "./components/ShortUrlResult";
import PublicUrls from  "./components/PublicUrls";
import RedirectPage from  "./components/RedirectPage";
import {getAllPublicUrls} from "./Services/urlService";
import "./App.css";
function App() {

  const [shortUrlData, setShortUrlData] = useState(null);
  const [urls,setUrls]=useState([]);
useEffect(()=>{
  loadUrls();
},[]);
  const loadUrls=async()=>{
try{
const result= await getAllPublicUrls();
console.log(result);
setUrls(result);
}
catch(error){
  console.error(error);
  
}
  };

  return (
    <Router>
      <Routes>

<Route path="/" element={
  <>
      <Header/>
      <UrlGeneratorCard setShortUrlData={setShortUrlData} />
      {shortUrlData && <ShortUrlResult data={shortUrlData} />} 
      <PublicUrls urls={urls}/>
      </>
}/> 
            {/* Short URL Redirect */}
        <Route path="/:code" element={<RedirectPage />} />

    </Routes>
</Router>
  );
}

export default App;
