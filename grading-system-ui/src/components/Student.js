const Student = ({student, onClick}) => {
    const handleClick = () => {
        onClick(student);
    }
    return (
        <>
            <div onClick={handleClick} style={{ cursor: "pointer" }}>
                <p>{student.name}</p>
            </div>
        </>
     );
}
 
export default Student;