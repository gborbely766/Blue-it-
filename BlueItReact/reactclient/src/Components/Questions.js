import React, { useState, useEffect } from 'react'



export default function QuestionCard() {
    const [question, setQuestion] = useState([])
    useEffect(() => {
        async function fetchData() {
            // You can await here
            const response = await fetch("https://localhost:7129/api/questions");
            const toJson = await response.json()
            setQuestion(toJson)
        }
        fetchData();
    }, []);
    return (
        <div>
            { question.map((question) => (
            <div key={question.id}>
                <div className="container justify-content-center mt-3">
                    <div className="card " style={{ maxWidth: "60rem" }}>
                        <h5 className="card-header text-white bg-primary text-center ">{question.title}</h5>
                        <div className="card-body">
                            <h5 className="card-title text-center">{question.message}</h5>
                        </div>
                    </div>
                </div>
            </div>
        ))}
        </div>
    )
}
