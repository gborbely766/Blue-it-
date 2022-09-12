import React, { useState } from "react";
import AddNewQuestion from "./Components/AddNewQuestion.js";
import Footer from "./Components/Footer.js";
import Header from "./Components/Header.js";
import QuestionCard from "./Components/Questions.js";




function App() {
  const [modalIsOpen, setModalOpen] = useState(false)
  function openModal() {
    setModalOpen(oldvalue => !oldvalue)
  }
  console.log(modalIsOpen)
  return (

    <div >
      <Header handleClick={openModal} />
      <QuestionCard />
      {modalIsOpen && <AddNewQuestion/>}
      <Footer />
    </div>
  );
}



export default App;
