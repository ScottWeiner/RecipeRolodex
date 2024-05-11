import Link from "next/link";


export default function AboutPage(){
    return(
    <div className="text-lg bg-orange-200 grid justify-items-center mb-4">
        <Link href='/'>Go back</Link>
        
        <h1>ABOUT THIS STUPID WEBSITE</h1>

        <p>My name is Scott and I'm naive enough to think that this may get me a job one day...</p>
    </div>
    )

}