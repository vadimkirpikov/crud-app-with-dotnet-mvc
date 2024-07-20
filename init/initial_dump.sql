CREATE TABLE IF NOT EXISTS public."Customers" (
    "Id" integer NOT NULL,
    "FirstName" character varying(30) DEFAULT ''::character varying NOT NULL,
    "LastName" character varying(30) DEFAULT ''::character varying NOT NULL,
    "Email" character varying(30) DEFAULT ''::character varying NOT NULL
);


ALTER TABLE public."Customers" OWNER TO vadimkirpikov;

--
-- Name: Customers_Id_seq; Type: SEQUENCE; Schema: public; Owner: vadimkirpikov
--

ALTER TABLE public."Customers" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Customers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Editors; Type: TABLE; Schema: public; Owner: vadimkirpikov
--

CREATE TABLE if not exists public."Editors" (
    "Id" integer NOT NULL,
    "Login" character varying(100) NOT NULL,
    "Password" character varying(100) NOT NULL
);


ALTER TABLE public."Editors" OWNER TO vadimkirpikov;

--
-- Name: Editors_Id_seq; Type: SEQUENCE; Schema: public; Owner: vadimkirpikov
--

ALTER TABLE public."Editors" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Editors_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
